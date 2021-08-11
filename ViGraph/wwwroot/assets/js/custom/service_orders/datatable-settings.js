function columnOptions(columnName, target) {
	switch (columnName) {
		case 'id':
			return [
				{ width: '80px', targets: target, className: columnName + ' text-center' },
				{
					render: function (data, type, row) {
						return data;
					}, targets: target
				},
			];
		case 'customer_id':
			return [
				{ width: '150px', targets: target },
				{
					render: function (data, type, row) {
						return row.customer.firstname + ' ' + row.customer.lastname;
					},
					targets: target,
				},
			];
		case 'total_fee':
			return [
				{ width: '100px', targets: target },
				{
					render: function (data, type, row) {
						return row['details_formatted']['total'];
					},
					targets: target,
				},
			];
		case 'office_name':
			return [
				{ width: '100px', targets: target },
				{
					render: function (data, type, row) {
						return row['office']['name'];
					},
					targets: target,
				},
			];
		case 'createdby':
			return [
				{ width: '150px', targets: target },
				{
					render: function (data, type, row) {
						return row['createdby']['name'];
					},
					targets: target,
				},
			];
		case 'delete_reason':
			return [
				{ width: '150px', targets: target },
				{
					render: function (data, type, row) {
                        if(row['delete_reason'] !== null && row['delete_reason']['reason'] !== undefined) {
                            let ext = '';
                            if(row['delete_reason']['reason'].length > 20) {
                                ext = ' ...';
                            }
                            return `<div data-toggle="tooltip" data-theme="dark" title="${row['delete_reason']['reason']}">${row['delete_reason']['reason'].substr(0, 20) + ext}`;
                        }
                        return '';
					},
					targets: target,
				},
			];
		case 'created_at':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
				},
			];
		case 'actions':
			return [
				{
					width: '130px',
					orderable: false,
					className: columnName + ' text-center',
					targets: target,
                    autoHide: false,
                    overflow: 'visible',
                    sortable: false,
				},
			];
		default:
			return [];
	}
}
