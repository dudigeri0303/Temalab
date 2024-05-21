import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import OwnerNavbar from "../components/OwnerNavbar";
import OwnerRestReservs from "../components/OwnerRestReservs";
import { useNavigate } from "react-router-dom";
import CheckAuth from "../common/CheckAuth";

export default function RestReservationPage() {
    const { id } = useParams();
    const navigate = useNavigate(); 
    const [reservations, setReservations] = useState([]);

    useEffect(() => {
        getReservations();
        CheckAuth("owner",navigate)
    }, []);

    const getReservations = async () => {
        const myHeaders = new Headers();

        const requestOptions = {
          method: "GET",
          headers: myHeaders,
          redirect: "follow",
          credentials: 'include',
        };

        try {
          const response = await fetch(`https://localhost:7114/api/Reservation/getReservationsByRestaurantId?restaurantId=${id}`, requestOptions);
          const data = await response.json();
          setReservations(data); 
        } catch (error) {
          console.error(error);
        }
    };

    return (
        <>
            <OwnerNavbar />
            <div className="container mt-3 ml-3">
                <a href={"/restaurantowner/" + id} className="btnstyle px-5 py-2">Vissza</a>
            </div>
            <div className="mt-3">
                {reservations.map((res) => (
                    <div key={res.id} className="mt-3">
                        <OwnerRestReservs data={res} />
                    </div>
                ))}
            </div>
        </>
    );
}