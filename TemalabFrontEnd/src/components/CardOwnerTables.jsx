import "../App.css";

export default function CardOwnerTables({id, numOfSeats, isReserved }) {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">AsztalID: {id}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">Férőhely: {numOfSeats}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">IsFoglalt: {isReserved}</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Töröl
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}