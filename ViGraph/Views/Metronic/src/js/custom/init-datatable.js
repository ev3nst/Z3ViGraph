$.fn.dataTable.ext.errMode = 'none';
function createReportTable(id, apiUrl, initColumns = [], config = {
    order: undefined
}) {
    let columns = [];
    for (let i = 0; i < initColumns.length; i++) {
        let column = initColumns[i];
        columns.push({
            data: column,
            className: column,
        });
    }

    if(columnsT.actions !== undefined) {
        columns.push({
            data: 'actions',
            className: 'actions text-center py-3',
            name: 'actions',
            autoHide: false,
            overflow: 'visible',
            sortable: false,
            responsivePriority: -1,
        });
    }

	columnsDef = [];
	for (let ix = 0; ix < columns.length; ix++) {
        if(columns[ix].data === 'id') {
            columns[ix].className = columns[ix].data + ' text-center';
        }
		let options = columnOptions(columns[ix]['data'], ix);
		if (options.length > 0) {
			columnsDef = columnsDef.concat(
				columnsDef,
				columnOptions(columns[ix]['data'], ix)
			);
		}
	}

	let currentDataTable = $(id);
	let theadHtml = '<thead><tr role="row">';
	for (let i = 0; i < columns.length; i++) {
		theadHtml +=
			"<th class='sorting_disabled' rowspan='1' colspan='1'>" +
			columnsT[columns[i].data] +
			'</th>';
	}
	theadHtml += '</tr></thead>';
	currentDataTable.html(theadHtml);

	currentDataTable = currentDataTable.DataTable({
		dom: 'Blfrtip',
		responsive: true,
		searchDelay: 500,
		serverSide: true,
		paging: true,
		pagingType: 'full_numbers',
		lengthMenu: [5, 10, 20, 50, 100, 200, 500],
		pageLength: 20,
		scrollX: false,
		scrollY: false,
		searching: false,
		ordering: true,
        select: true,
        processing: true,
		order: config.order,
		columnDefs: columnsDef,
		ajax: {
			url: apiUrl,
			cache: false,
			type: 'GET',
			data: function (data) {
				data['pagination'] = {};
				data['pagination']['perpage'] = data['length'];
				data['pagination']['page'] =
					Number(data['start'] / data['length']) + 1;

				data['sort'] = {};
				data['sort']['field'] =
					data['columns'][data['order'][0]['column']]['data'];
				data['sort']['order'] = data['order'][0]['dir'];
				data['query'] = {};

				data['query']['arama'] = $(
					'#datatable_advanced_search'
				).serialize();

				delete data.columns;
				return data;
			},
		},
		buttons: [
			{
				extend: 'print',
				className: 'd-none dt-print-button',
				exportOptions: {
					columns: ':visible',
				},
				text: 'Print',
			},
			{
				extend: 'excelHtml5',
				className: 'd-none dt-excel-button',
				exportOptions: {
					columns: ':visible',
				},
				filename: function () {
					return 'Export Excel';
				},
				title: function () {
					return 'Export Excel';
				},
			},
			{
				extend: 'csvHtml5',
				className: 'd-none dt-csv-button',
				exportOptions: {
					columns: ':visible',
				},
			},
			{
				extend: 'pdfHtml5',
				className: 'd-none dt-pdf-button',
				exportOptions: {
					columns: ':visible',
				},
				filename: function () {
					return 'Export PDF';
				},
				title: function () {
					return 'Export PDF';
				},
			},
		],
		columns: columns,
		language: {
			infoEmpty: ' ',
			emptyTable: datatableDict.emptyTable,
			zeroRecords: datatableDict.zeroRecords,
			loadingRecords: datatableDict.loadingRecords,
			processing: '<div class="spinner spinner-primary spinner-track"></div>',
			lengthMenu: 'Limit _MENU_',
			info: datatableDict.info,
		},

		createdRow: function (row, data, dataIndex) {
			$(row).attr('data-id', data.id);
		},
		createdCell: function (column, data, dataIndex) {},
	});

    $('#custom-datatable-limit-list a').click(function() {
        const limit = Number($(this).data('limit'));
        currentDataTable.page.len(limit).draw();
        $('#datatable-limit').text('(' + limit + ')');
        $('#custom-datatable-limit-list li a').each(function() {
            $(this).removeClass('navi-link-active');
        });
        $(this).addClass('navi-link-active');
    });

    return currentDataTable;
}
