$(document).ready(function () {

    cargarDataTableSQL();
    cargarDataTableOracle();
    obtenerValorOracle();
    obtenerValorSQL();
});

function cargarDataTableSQL() {

    datatableSQL = $("#tbDataSQL").DataTable({
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
            { "orderable": false, "targets": [0, 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
            {
                "targets": "_all",
                "className": 'dt-head-center dt-body-center'
            }
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

    $('#tbDataSQL').on('search.dt', function () {
        const searchValueSQL = datatableSQL.search();

        $('#sb-data-sql').val(searchValueSQL);
    });

}

function cargarDataTableOracle() {

    datatableOracle = $("#tbDataOracle").DataTable({
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
            { "orderable": false, "targets": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18] },
            {
                "targets": "_all",
                "className": 'dt-head-center dt-body-center'
            },
            {
                "width": 150,
                "targets": [3, 5, 9]
            },
            {
                "width": 80,
                "targets": [2, 8]
            }
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

    $('#tbDataOracle').on('search.dt', function () {
        const searchValueOracle = datatableOracle.search();

        $('#sb-data-oracle').val(searchValueOracle);
    });
}

function obtenerValorOracle() {
    $('#btn-oracle-excel').click(function () {

        const valueOracle = document.getElementById('sb-data-oracle').value;

        const $btn = $(this);
        $btn.prop('disabled', true);

        $.ajax({
            url: '/DataOracle/ExcelDownload?name=' + valueOracle,
            type: 'GET',
            xhrFields: {
                responseType: 'blob'
            },
            success: function (data) {
                var a = document.createElement('a');
                var url = window.URL.createObjectURL(data);
                a.href = url;
                a.download = 'Resultados ' + valueOracle.toUpperCase() + '.xlsx';

                document.body.append(a);
                a.click();
                a.remove();

                window.URL.revokeObjectURL(url);
            },
            error: function () {
                alert('error')
            },
            complete: function () {
                $btn.prop('disabled', false);
            }
        });
    });
}

function obtenerValorSQL() {
    $('#btn-sql-excel').click(function () {

        const valueSQL = document.getElementById('sb-data-sql').value;

        const $btn = $(this);
        $btn.prop('disabled', true);

        $.ajax({
            url: '/DataSQL/ExcelDownload?name=' + valueSQL,
            type: 'GET',
            xhrFields: {
                responseType: 'blob'
            },
            success: function (data) {
                var a = document.createElement('a');
                var url = window.URL.createObjectURL(data);
                a.href = url;
                a.download = 'Resultados ' + valueSQL.toUpperCase() + '.xlsx';

                document.body.append(a);
                a.click();
                a.remove();

                window.URL.revokeObjectURL(url);
            },
            error: function () {
                alert('error')
            },
            complete: function () {
                $btn.prop('disabled', false);
            }
        });
    });
}