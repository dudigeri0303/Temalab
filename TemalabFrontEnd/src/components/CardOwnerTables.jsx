import "../App.css";

export default function CardOwnerTables() {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">AsztalID</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">Férőhely</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">IsFoglalt</label>
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