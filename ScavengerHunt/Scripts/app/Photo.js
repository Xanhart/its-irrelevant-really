﻿$(document).ready(function () {
    

    var selectedAnimal;

    $(".photo-btn").click(function () {
        $("#animal-select").hide();
        $("#take-picture").show();
        video = document.getElementById('video');
        video.play();

        selectedAnimal = $(this)[0].id;
        
    })

    $("#submitbutton").click(function () {
        var image = canvas.toDataURL('image/png');
        var animal = selectedAnimal;
        var user = $(".idkeeper")[0].id
        console.log(user);

        function sendFile(fileData) {
            var formData = new FormData();

            formData.append('userID', user);
            formData.append('selectedAnimal', selectedAnimal);
            formData.append('imageData', fileData);

            $.ajax({
                type: 'POST',
                url: 'Photos/Upload',
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data.success) {
                        //console.log("filedata: " + data.message)
                        alert('Awesome! Can you find the rest?');
                        window.location.href = 'Home'
                    } else {
                        //console.log("no success: " + data);
                        alert('There was an error uploading your file!');
                    }
                },
                error: function (data) {
                    //console.log("error: " + data);
                    alert('There was an error uploading your file!');
                }
            });
        }

        sendFile(image)
        
    })

});