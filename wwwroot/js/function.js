function complete(k) {
    var k_ = jQuery.parseJSON(k);
    //var k_ = JSON.parse(k);
    var value = k_["Sheet1"];
    console.log(value);
    document.getElementById("ds_").value = JSON.stringify(value);
    document.getElementById("submit").click();
}
function run() {
    import_excel(complete);
}