window.onload = function () {
    listarCama();
}

function listarCama() {
    pintar({
        url: "Cama/listarCama",
        id:"divTabla",
        cabeceras: ["Id cama","nombre","descripcion"],
        propiedades: ["idCama", "nombre","descripcion"]

    }, {
            busqueda: true,
            url: "Cama/FiltrarCama",
            nombreParametro: "nombre",

            //el id se se otorga el input
            id:"txtNombreCama",
            placeholder: "Ingrese nombre de la cama",
            button: false,
            type:"text"
    }, {
            type: "fieldset",
            legend:"Dato de la camas",

            formulario: [
            [
                    {
                      class: "mb-3 col-md-6",
                      type: "text",
                      label: "Id Cama",
                      name: "id",
                      value: 0,
                      readonly: true
                    },
                    {
                        class: "mb-3 col-md-6",
                        type: "text",
                        label: "Nombre Cama",
                        name: "nombre",
                        value: "",
                        readonly: false
                    }

            ],
            [
                {
                    class: "col-md-12",
                    type: "text",
                    label: "Descripcion Cama",
                    name: "descripcion",
                    value: "",
                    readonly: false
                }
            ]

            ]

    })
}
