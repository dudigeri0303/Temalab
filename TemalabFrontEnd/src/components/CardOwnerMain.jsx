import "../App.css";

export default function CardOwnerMain() {
 
  return (
    <>
     <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-text">
                  Étterem neve
                </label>{" "}
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-text">
                  ★★★★★
                </label>{" "}
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem címe
                </label>{" "}
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Szerkesztés
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
</>
);
}