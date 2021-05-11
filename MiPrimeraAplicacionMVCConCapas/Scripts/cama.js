window.onload = function () {
    listarCama();
}

function listarCama() {
    pintar({
        url: "Cama/listarCama",
        id: "divTabla",
        cabeceras: ["Id cama", "nombre", "descripcion"],
        propiedades: ["idCama", "nombre", "descripcion"],
        editar: true,
        eliminar: true

    }, {
        busqueda: true,
        url: "Cama/FiltrarCama",
        nombreParametro: "nombre",

        //el id se se otorga el input
        id: "txtNombreCama",
        placeholder: "Ingrese nombre de la cama",
        button: false,
        type: "text"
    },
        {
        type: "fieldset",
            guardar: true,
            limpiar: true,
            formulariogenerico:true,
        legend: "Dato de la camas",

        formulario: [
            [
                {
                    class: "mb-3 col-md-6",
                    label: "Id Cama",
                    name: "id",
                    value: 0,
                    readonly: true
                },
                {
                    class: "mb-3 col-md-6",
                    label: "Nombre Cama",
                    name: "nombre"

                }

            ],
            [
                {
                    class: "col-md-12",
                    type: "textarea",
                    label: "Descripcion Cama",
                    name: "descripcion",
                    rows: "5",
                    cols: "10"

                }
            ]

        ]

    });
}
