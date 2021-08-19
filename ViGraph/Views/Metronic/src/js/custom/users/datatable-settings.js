function columnOptions(columnName, target) {
	switch (columnName) {
		case 'Id':
			return [
				{ width: '80px', targets: target, className: columnName + ' text-center' },
				{
					render: function (data, type, row) {
						return data;
					}, targets: target
				},
			];
		case 'FullName':
			return [
				{ width: '200px', targets: target },
				{
					render: function (data, type, row) {
						return data;
					},
					targets: target,
				},
			];
		case 'RoleName':
			return [
				{ width: '100px', targets: target },
				{
					render: function (data, type, row) {
						return data;
					},
					targets: target,
				},
			];
		case 'Email':
			return [
				{ width: '200px', targets: target },
				{
					render: function (data, type, row) {
						return `<a href="mailto:${data}" title="Email: ${row.FullName}">${data}</a>`;
					}, targets: target
				},
			];
		case 'LastLogin':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
				},
			];
		case 'LastLogout':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
				},
			];
		case 'CreatedAt':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
				},
			];
		case 'ActionsHTML':
			return [
				{
					width: '130px',
					orderable: false,
					className: columnName + ' text-center',
					targets: target,
                    autoHide: false,
                    overflow: 'visible',
                    sortable: false,
                    responsivePriority: -1,
				},
			];
		default:
			return [];
	}
}
