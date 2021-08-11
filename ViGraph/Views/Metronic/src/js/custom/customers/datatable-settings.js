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
		case 'name':
			return [
				{ width: '150px', targets: target },
				{
					render: function (data, type, row) {
						return row.firstname + ' ' + row.lastname;
					},
					targets: target,
				},
			];
		case 'cnic':
			return [
				{ width: '100px', targets: target },
				{
					render: function (data, type, row) {
						return data;
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
		case 'created_by':
			return [
				{ width: '150px', targets: target },
				{
					render: function (data, type, row) {
						return row['created_by']['name'];
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
					width: '100px',
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
