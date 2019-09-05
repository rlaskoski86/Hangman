$(document).ready(function () {

    $("#btnPlay").on("click", function () {
        location.pathname.trim();
        model = {};
        model.CorrectedLetters = $("#lblCorrectedLetters").text();
        model.TriedLetters = $("#lblTriedLetters").text();
        model.Shot = $("#txtShot").val();
        model.Word = $("#hdnWord").val();
        model.ErrorsQuantity = $("#lblErrorsQuantity").text();
        
        
        $.ajax({
            url: "http://localhost:40909/Game/Play",
            type: "POST",
            data: { model: model },
            success: function (result) {
                
                $("#lblCorrectedLetters").text(result.correctedLetters);
                $("#lblTriedLetters").text(result.triedLetters);
                $("#txtShot").val("");
                $("#hdnWord").val(result.word);
                $("#lblErrorsQuantity").text(result.errorsQuantity);
                var imgN = "";
                if (result.errorsQuantity > 0)
                    imgN = result.errorsQuantity;
                $("#imgHang").attr("src", "/images/gallows" + imgN + ".jpg");

                if (result.errorsQuantity == "6") {
                    $("#lblGameOver").text(result.message);
                }
                else if (result.message == "Congratulations, you won the game.")
                    $("#lblGameOver").text(result.message);
                
            },
            error: function (error) {
                
            }
        });
    });


});