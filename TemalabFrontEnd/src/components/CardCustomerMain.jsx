import "../App.css";

export default function CardCustomerMain() {
 
  return (
    <>
    <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-6">
                <label htmlFor="restaurantName" className="card-text">
                  Étterem név
                </label>
              </div>
              <div className="col-md-6 d-flex justify-content-end">
                <label htmlFor="stars" className="card-text">
                  ★★★★★
                </label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem stílusa
                </label>
              </div>
              <div className="col d-flex justify-content-end">
                <button className="likebtn">
                  <img
                    src="./public/likebtn.png"
                    style={{ height: "40px", width: "40px" }}
                  />
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label htmlFor="restaurantPlace" className="card-Altext">
                  Étterem helye
                </label>
              </div>
            </div>
          </div>
        </div>
      </section>
</>
);
}