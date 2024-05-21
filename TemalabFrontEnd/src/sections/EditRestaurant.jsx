import { useState } from "react";
import { useParams } from 'react-router-dom';
import OwnerNavbar from "../components/OwnerNavbar";



export default function EditRestaurant() {

    const id = useParams();
    //const [restaurant, setRestaurantData] = useState("");

    const [name, setName] = useState('');
    const [postCode, setPostCode] = useState('');
    const [city, setCity] = useState('');
    const [street, setStreet] = useState('');
    const [houseNumber, setHouseNumber] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [description, setDescription] = useState('');
    const [label, setLabel] = useState('kajálda haha');


    const updateRestaurant = () => {


        const newData = {
            name: name,
            postCode: postCode,
            city: city,
            street: street,
            houseNumber: houseNumber,
            phoneNumber: phoneNumber,
            description: description,
            label: label
        };

        const putRequestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include',
            body: JSON.stringify(newData)
        };

        fetch("https://localhost:7114/api/Restaurant/updateRestaurantById?restaurantId=" + id.id, putRequestOptions)
            .then(handleResponse)
            .catch(handleError);

        function handleResponse(response) {
            if (response.ok) {
                alert("Változtatások mentve");
            } else {
                throw new Error('Hiba történt a módosítás során');
            }
        }

        function handleError(error) {
            console.error('Hiba történt:', error);
            alert("Hiba történt a módosítás során");
        }
        window.open("/mainPageOwner", "_self");
    };

    const goBack = () => {
        window.open("/mainPageOwner", "_self");
    }


    /*
        const getRestaurantData = async () => {
            const myHeaders = new Headers();
    
            const requestOptions = {
                method: "GET",
                headers: myHeaders,
                redirect: "follow",
                credentials: 'include',
                xhrFields: { withCredentials: true },
            };
    
            try {
                const response = await fetch("https://localhost:7114/api/Restaurant/GetRestaurantById?restaurantId=" + id.id, requestOptions);
                const data = await response.json();
                setRestaurantData(data);
                console.log(data);
                console.log(id);
            } catch (error) {
                console.log(error);
            }
        };
        getRestaurantData();
    
    */

    return (
        <>
            <OwnerNavbar></OwnerNavbar>
            <section className="container py-3">
                <form method="post">
                    <div className="mb-3">
                        <label className="form-label">Étterem név</label>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Étterem név"
                            onChange={(e) => setName(e.target.value)}
                            required />
                    </div>

                    <label className="form-label">Cím</label>
                    <div className="row">
                        <div className="col-md-2">
                            <div className="mb-3">
                                <label className="form-label">Irányítószám</label>
                                <input
                                    type="number"
                                    className="form-control"
                                    placeholder="Irányítószám"
                                    onChange={(e) => setPostCode(e.target.value)}
                                    required />
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="mb-3">
                                <label className="form-label">Város</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    placeholder="Város"
                                    onChange={(e) => setCity(e.target.value)}
                                    required />
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="mb-3">
                                <label className="form-label">Utca</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    placeholder="Utca"
                                    onChange={(e) => setStreet(e.target.value)}
                                    required
                                />
                            </div>
                        </div>
                        <div className="col-md-2">
                            <div className="mb-3">
                                <label className="form-label">Házszám</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    placeholder="Házszám"
                                    onChange={(e) => setHouseNumber(e.target.value)}
                                    required
                                />
                            </div>
                        </div>
                    </div>

                    <div className="col-md-6 mb-3">
                        <label className="form-label">Telefonszám</label>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Telefonszám"
                            onChange={(e) => setPhoneNumber(e.target.value)}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Leírás</label>
                        <textarea
                            type="text"
                            className="form-control"
                            placeholder="Leírás"
                            onChange={(e) => setDescription(e.target.value)}
                        />
                    </div>

                    <div className="row">
                        <div className="col-md-3 offset-sm-4 mb-2">
                            <button
                                onClick={updateRestaurant}
                                type="button"
                                className="avgbtn"
                            >
                                Módosít
                            </button>
                        </div>
                        <div className="col-md-2 mb-2">
                            <button
                                onClick={goBack}
                                type="button"
                                className="avgbtn"
                            >
                                Mégse
                            </button>
                        </div>
                    </div>
                </form>
            </section>
        </>
    );
}

