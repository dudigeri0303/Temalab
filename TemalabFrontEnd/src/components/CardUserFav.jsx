import "../App.css";

export default function CardUserFav() {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-3">
                <label className="card-text">Étterem név</label>
              </div>
              <div className="col-md-4">
                <label className="card-text">★★★★★</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">Étterem stílusa</label>
              </div>
              <div className="col">
                <button
                  type="button"
                  className="cardbtn float-end"
                  style={{ margin: "0" }}
                >
                  Eltávolítás
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">Étterem helye</label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}