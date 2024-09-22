$(document).ready(function () {
    $('#detailCampusAtPersonelTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
        "columns": [
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
            { "orderDataType": "dom-text-numeric" },
        ]
    });
});