// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Capto un evento onclick, cuando toco en la clase fa-star se dispara
$(".fa-star").on('click', function (event) {
    let voto = $(this).attr('data-clasif');
    let idv = $(this).attr('data-vid');
    
    alert("¡Calificaste correctamente!");

    $.post('/Vehiculos/Calificacion', {vehiculoId: idv, voto: voto }, //Le pega a la url y le manda los parametros - lo que tengo en el controller
        function () {
            location.reload();
        }
    );
    
});


// cada vez que carga la pagina hace un post, esta puesto en el layout
$.post('/Vehiculos/Porcalificacion',
    function (data) {

        //data devuelve todos los vehiculos del sitio

        $.each(data, function (i, element) {
            //console.log(element);
            let elementId = element.id;

            //encuentro el auto y obtengo las estrellas, cada span es un elementinn y pongo cada posicion para las estrellas
            //despues chequeo el voto que llega y marco chequeadas las estrellas que sean
            $(".clasificacion-" + elementId).each(function (index, elementInn) {
                
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