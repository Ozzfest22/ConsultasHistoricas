$(document).ready(function () {

    cargarDataTable();

});

function cargarDataTable() {

    datatable = $("#tbData").DataTable({
        "processing": true,
        "serverSide": true,
        "responsive": false,
        "ajax": {
            "url": "/DataSQL/GetData",
            "type": "POST",
            "datatype": "json"
        },
        "lengthMenu": [5, 10, 15],
        "columns": [
            { "data": "codigoHistoria" },
            { "data": "nombre" },
            { "data": "ordenAño" },
            { "data": "ordenNumero" },
            { "data": "ordenFecha" },
            { "data": "nombreExamen" },
            { "data": "fechaIngreso" },
            { "data": "resultado" },
            { "data": "fechaResultado" },
            { "data": "ultimoResultado" },
            { "data": "fechaUltResultado" },
            { "data": "ultimoResultado2" },
            { "data": "fechaUltResultado2" },
        ],
        "columnDefs": [
            { "orderable": false, "targets": [0, 1, 3, 4, 5, 6, 7, 8, 9, 10, 11 ,12] }
        ],
        scrollX: true,
        scrollCollapse: true,
        scrollY: '500px',
        search: {
            return: true
        },
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        layout: {
            topStart: {
                buttons: [
                    'pageLength', 'copy', 'excel', 'pdf'
                ]
            }
        }
    });

}