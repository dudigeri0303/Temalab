import "../App.css";

export default function CardAddReview({ idReview, setIdReview, rate, setRate, review, setReview, onSubmit }) {


  const handleSubmit = () => {
    onSubmit({ idReview, rate, review });
    setIdReview("");
    setRate(1);
    setReview("");
  };
  
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">

            <div className="row">
              <div>
              <label className="card-Altext">Id</label>
              <input id="idReview" value={idReview} onChange={(e) => setIdReview(e.target.value)} type="string"/>
              </div>
              <div className="text-center">
              <label className="card-Altext">Értékelés</label>
              <input id="rate" value={rate} onChange={(e) => setRate(e.target.value)} type="number" min={1} max={5}/>
              </div>
              <div className="col-sm-12 text-center">
                <textarea id="review" value={review} onChange={(e) => setReview(e.target.value)} placeholder="Vélemény" maxLength={250}></textarea>
              </div>
            </div>
            <button onClick={handleSubmit}>Vélemény elküldése</button>
          </div>
        </div>
      </section>
    </>
  );
}