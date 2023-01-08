
        $.ajax({
            async: false,
            crossdomain: true,
            url: "https://localhost:7123" + "/api/sehir/getallcity",
            method: "get",
            headers: {
            },
            success: function (responsee) {
                window.datas = responsee;
                console.log(responsee);
            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
            }
        });
  

$('#products-data-source').dxSelectBox({
    dataSource: window.datas,
    displayExpr: "şehirler",
    valueExpr: "id",
});


        
    

