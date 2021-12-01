// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".fa-star").on('click', function (event) {
    let voto = $(this).attr('data-clasif');
    let idv = $(this).attr('data-vid');
    alert("¡Calificaste correctamente!");
    $.post('/Vehiculos/Calificacion', { usuarioId: 1, vehiculoId: idv, voto: voto },
        function (returnedData) {
            console.log(returnedData);
        }
    );
    location.reload();
});



$.post('/Vehiculos/Porcalificacion', { usuarioId: 2 },
    function (data) {


        $.each(data, function (i, element) {
            //console.log(element);
            let elementId = element.id;

            $(".clasificacion-" + elementId).each(function (index, elementInn) {
                // element == this
                //console.log($(elementInn)[0].children[0]);
                let estrellaCinco = $(elementInn)[0].children[0];
                let estrellaCuatro = $(elementInn)[0].children[1];
                let estrellaTres = $(elementInn)[0].children[2];
                let estrellaDos = $(elementInn)[0].children[3];
                let estrellaUno = $(elementInn)[0].children[4];

                if (element.voto === 1) {
                    $(estrellaUno).addClass('checked');
                }

                if (element.voto === 2) {
                    $(estrellaUno).addClass('checked');
                    $(estrellaDos).addClass('checked');
                }

                if (element.voto === 3) {
                    $(estrellaUno).addClass('checked');
                    $(estrellaDos).addClass('checked');
                    $(estrellaTres).addClass('checked');
                }

                if (element.voto === 4) {
                    $(estrellaUno).addClass('checked');
                    $(estrellaDos).addClass('checked');
                    $(estrellaTres).addClass('checked');
                    $(estrellaCuatro).addClass('checked');
                }

                if (element.voto === 5) {
                    $(estrellaUno).addClass('checked');
                    $(estrellaDos).addClass('checked');
                    $(estrellaTres).addClass('checked');
                    $(estrellaCuatro).addClass('checked');
                    $(estrellaCinco).addClass('checked');
                }

            });



        });


    }
);