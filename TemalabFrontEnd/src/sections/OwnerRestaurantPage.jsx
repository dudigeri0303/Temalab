import GoogleMap from "../components/GoogleMap";
import OwnerNavbar from "../components/OwnerNavbar";

export default function OwnerRestaurantPage(){
    return(
        <>
            <OwnerNavbar/>
            <div className="container">
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Étlap</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Asztalok kezelése</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Foglalások megtekintése</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12 col-md-6 contactus d-flex align-items-center">
                        <div className="mx-auto">
                            <h3 className="contactustext">Elérhetőségeink:</h3>
                            <p className="contactustext">Teszt Étterem név</p>
                            <p className="contactustext">tesztetterem@gmail.com</p>
                            <p className="contactustext">+36 30 123 1452</p>
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <GoogleMap/>
                    </div>
                </div>
            </div>
        </>
    )
}