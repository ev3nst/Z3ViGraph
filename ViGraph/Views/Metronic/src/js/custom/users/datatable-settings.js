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
				{ width: '250px', targets: target },
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
						return row['offices'].map(o => o.name).join(', ');
					},
					targets: target,
				},
			];
		case 'role_name':
			return [
				{ width: '100px', targets: target },
				{
					render: function (data, type, row) {
						return row['role']['name'];
					},
					targets: target,
				},
			];
		case 'email':
			return [
				{ width: '270px', targets: target },
				{
					render: function (data, type, row) {
						return `<a href="mailto:${data}" title="Email: ${row.name}">${data}</a>`;
					}, targets: target
				},
			];
		case 'last_login':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
				},
			];
		case 'last_logout':
			return [
				{ width: '130px', targets: target },
				{
					render: function (data, type, row) {
						return new Date(data.trim()).toLocaleDateString("tr-TR");
					}, targets: target
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
                    responsivePriority: -1,
				},
			];
		default:
			return [];
	}
}
