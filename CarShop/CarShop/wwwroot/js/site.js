

$('#car-list')
    .load(`/Home/CarsList`)

$('#searchBtn').on('click', function () {
    const searchText = $('#searchText').val()

    $('#car-list')
        .load(`/Home/CarsList/?search=${searchText}`)


    fetch('/Home/CarsJson')
        .then(response => response.json())
        .then(cars => console.log(cars))
})