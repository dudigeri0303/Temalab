import "../App.css";

export default function CardAddReview() {


  
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">

            <div className="row">
              <div className="text-center">
              <label className="card-Altext">Értékelés</label>
              <input id="rate" type="number" min={1} max={5}/>
              </div>
              <div className="col-sm-12 text-center">
                <textarea id="review" placeholder="Vélemény" maxLength={250}></textarea>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}