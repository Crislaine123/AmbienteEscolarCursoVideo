



$(document).ready(function () {


    function showMessage(type, message) {
        var box = $('#message-box');
        box.removeClass("alert-success alert-danger").addClass("alert-" + type)
        box.text(message).fadeIn();

        setTimeout(function () {
            box.fadeOut()
        }, 3000);
    }
    $(document).on('blur', '.matricula', function () {
        var matricula = $(this).val();
        var row = $(this).closest('tr');

        if (matricula) {
            $.ajax({
                url: '/Aluno/BuscarAlunoPorMatricula',
                method: 'GET',
                data: { matricula: matricula },
                success: function (response) {
                    if (response.dados) {
                        row.find('.nome-aluno').text(response.dados.nome)
                    } else {
                        row.find('.nome-aluno').text('Aluno não encontrado!')
                    }
                }

            })
        } else {
            row.find('.nome-aluno').text('');
        }
    })
    $(".editable").on("blur", function () {

        var linha = $(this).closest('tr');
        var idHistorico = linha.attr('data-id');
        var campo = $(this).attr('data-field');
        var valor = $(this).text();

        if (valor == null || valor == "") {
            return null;
        }


        $.post("/Historico/AtualizarNota", {idHistorico: idHistorico, campo:campo, valor:valor}, function (response) {

            if (response.resultado) {
                linha.find('.media').text(response.media);
                showMessage("success", "Alteração salva com sucesso!");
            } else {
                showMessage("danger", "Erro na alteração!");
            }



        }).fail(function () {
            showMessage("danger", "Erro na comunicação com o servidor!");
        })



    })
    $(document).on("click", ".btn-delete", function () {

        var linha = $(this).closest('tr')
        var idHistorico = linha.attr("data-id")


        $.post("/Historico/RemoverNota", { idHistorico: idHistorico }, function (response) {

            if (response.resultado) {
                linha.remove();
                showMessage("success", "Usuário Removido com sucesso!");
            } else {
                showMessage("danger", "Erro ao remover o aluno!");
            }

        }).fail(function () {
            showMessage("danger", "Erro na comunicação com o servidor!");
        })

    })


    $(document).on("click", ".btn-add", function () {
        debugger;
        var linha = $("#novoHistorico");
        var matricula = $(".matriculaAdd").val();
        var materiaId = $("#materiaSelect").val();

        var notas = {
            Nota1: linha.find("td:eq(3)").text(),
            Nota2: linha.find("td:eq(4)").text(),
            Nota3: linha.find("td:eq(5)").text(),
            Nota4: linha.find("td:eq(6)").text()
            }

        var temNotaInvalida = Object.values(notas).some(nota => nota == null || nota == "");   


        if (temNotaInvalida || matricula == null || matricula == "" ) {
            showMessage("danger", "Alguma informação não foi inserida!");
            return;
        }

        $.post("/Historico/SalvarNotas", { notas, matricula, materiaId }, function (response) {


            if (response.resultado) {
                location.reload();
            } else {
                showMessage("danger", "Ocorreu um erro ao cadastrar a nota!");
            }


        }).fail(function () {
            showMessage("danger", "Erro na comunicação com o servidor!");
        })

    })

})

             