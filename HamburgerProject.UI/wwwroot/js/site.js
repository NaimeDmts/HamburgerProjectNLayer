function DeleteMalzeme(id) {
    var result = confirm("Silmek istediğinize Emin misiniz?");
    if (result) {
        $.ajax({
            url: "/Manager/EkstraMalzemeDelete/" + id,
            method: "get",
            success: function (response) {

                location.reload(true);
            }
        });
       
    }
}
function DeleteMenu(id) {
    var result = confirm("Silmek istediğinize Emin misiniz?");
    if (result) {
        $.ajax({
            url: "/Manager/MenuDelete/" + id,
            method: "get",
            success: function (response) {

                location.reload(true);
            }
        });

    }
}
function DeleteSiparis(id) {
    var result = confirm("Silmek istediğinize Emin misiniz?");
    if (result) {
        $.ajax({
            url: "/Manager/SiparisDelete/" + id,
            method: "get",
            success: function (response) {

                location.reload(true);
            }
        });

    }
}