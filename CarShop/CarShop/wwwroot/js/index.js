function createTableRow(car) {
    const tr = document.createElement('tr')

    const titleTd = document.createElement('td')
    titleTd.append(car.title)
    tr.append(titleTd)

    const modelTd = document.createElement('td')
    modelTd.append(car.model)
    tr.append(modelTd)


    const priceTd = document.createElement('td')
    priceTd.append(car.price)
    tr.append(priceTd)

    return tr
}

async function getCars() {
    const response = await fetch('/api/cars')
    if (response.ok === true) {
        const cars = await response.json()
        let rows = document.querySelector('tbody')
        cars.forEach(car => rows.append(createTableRow(car)))
    }
}

async function createCar(title, model, price) {
    const response = await fetch('/api/cars', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify({
            title,
            model,
            price: +price
        })
    })

    if (response.ok === true) {
        const car = await response.json()
        document.querySelector('tbody').append(createTableRow(car))
    } else {
        document.getElementById('errors').innerHTML = ''

        const errorData = await response.json()
        console.log(errorData)
        console.log(errorData.errors)

        if (errorData) {
            if (errorData.errors) {
                for (let error in errorData.errors) {
                    showError(errorData.errors[error])
                }
            }

            if (errorData['TitleModelError']) {
                showError(errorData['TitleModelError'])
            }

            if (errorData['PriceModelError']) {
                showError(errorData['PriceModelError'])
            }

            document.getElementById('errors').style.display = 'block'
        }

    }
}

function showError(errors) {
    errors.forEach(error => {
        const p = document.createElement('p')
        p.append(error)
        document.getElementById('errors').append(p)
    })
} 

document.forms['carForm'].addEventListener('submit', function (e) {
    e.preventDefault()
    const form = document.forms['carForm']
    const title = form.elements['title'].value
    const model = form.elements['model'].value
    const price = form.elements['price'].value

    createCar(title, model, price)
})


getCars()