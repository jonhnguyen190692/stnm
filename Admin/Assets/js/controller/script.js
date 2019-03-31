$(function () {
});

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}
//Here $(this)$(function () {
//});  

AjaxCall('/Admin/ProductCategory/GetCountries', null).done(function (response) {
    if (response.length > 0) {
        $('#countryDropDownList').html('');
        var options = '';
        //options += '<option value="0">Select</option>';
        for (var i = 0; i < response.length; i++) {
            options += '<option value="' + response[i].Value + '">' + response[i].Text + '</option>';
        }
        $('#countryDropDownList').append(options);
    }
}).fail(function (error) {
    alert(error.StatusText);
});   


$('#countryDropDownList').on("change", function () {
    var country = $('#countryDropDownList').val();
    
    var obj = { country: country };
    //alert(obj.country);
    AjaxCall('/Admin/ProductCategory/GetStates/' + obj.country + '', JSON.stringify(obj), 'POST').done(function (response) {
        if (response) {
            $('#stateDropDownList').html('');
            var options = '';
            //options += '<option value="Select">Select</option>';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + JSON.stringify(response[i].ID) + '">' + JSON.stringify(response[i].Name)+ '</option>';
            }
            $('#stateDropDownList').append(options);

        }
    }).fail(function (error) {
        alert(error.StatusText);
    });
});  

$('#stateDropDownList').on('change', function () {
    var parentId = $('#stateDropDownList').val();
    //alert(parentId);
    //var id = $('#txt-parent').add('value', parentId.Value);
    //var id = $('#txt-parent').attr("data-value", parentId);
    var id = $('#txt-parent').html(parentId.Value.Text);
    alert(id.Value);
})