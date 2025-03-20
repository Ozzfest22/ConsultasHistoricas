$(document).ready(function () {

    cargarDataTableSQL();
    cargarDataTableOracle();
});

function cargarDataTableSQL() {

    datatable = $("#tbDataSQL").DataTable({
        "processing": true,
        "serverSide": true,
        "deferLoading": 0,
        "responsive": false,
        "ajax": {
            "url": "/DataSQL/GetData",
            "type": "POST",
            "datatype": "json"
        },
        "lengthMenu": [10, 50, 100],
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
                    'pageLength', 'copy', 'excel', 'pdf',
                ]
            }
        }
    });

}

function cargarDataTableOracle() {

    datatable = $("#tbDataOracle").DataTable({
        "processing": true,
        "serverSide": true,
        "deferLoading": 0,
        "responsive": false,
        "ajax": {
            "url": "/DataOracle/GetData",
            "type": "POST",
            "datatype": "json"
        },
        "lengthMenu": [10, 50, 100],
        "columns": [
            { "data": "ordenAño" },
            { "data": "nroOrden" },
            { "data": "cabeceraOrdServicio" },
            { "data": "paciente" },
            { "data": "edad" },
            { "data": "medico" },
            { "data": "fechaOrden" },
            { "data": "codigoHistoria" },
            { "data": "resultado" },
            { "data": "examen" },
            { "data": "metodo" },
            { "data": "unidad" },
            { "data": "valorReferencial" },
            { "data": "seccion" },
            { "data": "perfil" },
            { "data": "fechaMuestra" },
            { "data": "resultadoOrigen" },
            { "data": "resultadoNuevo" },
            { "data": "servicio" }
        ],
        "columnDefs": [
            { "orderable": false, "targets": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18] }
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
                    'pageLength', 'copy', 'excel', 'pdf',
                ]
            }
        }
    });

}