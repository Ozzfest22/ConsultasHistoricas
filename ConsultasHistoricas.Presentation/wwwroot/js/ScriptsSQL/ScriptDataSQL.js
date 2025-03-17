$(document).ready(function () {

    datatable = $("#tbData").DataTable({
        "processing": true,
        "serverSide": true,
        "responsive": true,
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
            { "data": "codigoExamen" },
            { "data": "nombreExamen" },
            { "data": "resultado" },
            { "data": "fechaResultado" },
            { "data": "ultimoResultado" },
            { "data": "fechaUltResultado" },
            { "data": "ultimoResultado2" },
            { "data": "fechaUltResultado2" },
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        layout: {
            topStart: {
                buttons: [
                    'copy', 'excel', 'pdf'
                ]
            }
        }
    });

});