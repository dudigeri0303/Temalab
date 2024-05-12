import "../App.css";

export default function CardAddReview({
  idReview,
  setIdReview,
  rate,
  setRate,
  review,
  setReview,
  postSubmit,
  handleClose,
}) {

  const submitReview = () => {
    postSubmit({ idReview, rate, review });
    setIdReview("");
    setRate();
    setReview("");
    handleClose();
  };

  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm-12 p-2 d-flex align-items-center justify-content-center">
                <label className="card-Altext p-2">Id</label>
                <input
                  id="idReview"
                  value={idReview}
                  onChange={(e) => setIdReview(e.target.value)}
                  type="string"
                />
              </div>
              <div className="col-sm-12 p-2 d-flex align-items-center justify-content-center">
                <label className="card-Altext p-2">Értékelés</label>
                <input
                  id="rate"
                  value={rate}
                  onChange={(e) => setRate(e.target.value)}
                  type="number"
                  min={1}
                  max={5}
                  placeholder="1-5"
                  required
                />
              </div>
              <div className="col-sm-12 p-2 d-flex align-items-center justify-content-center">
                <label className="card-Altext p-2">Vélemény</label>
                <textarea
                  id="review"
                  value={review}
                  onChange={(e) => setReview(e.target.value)}
                  placeholder="Vélemény"
                  maxLength={250}
                  required
                ></textarea>
              </div>
            </div>
          </div>
        </div>
        <div className="text-center m-3">
          <button className="avgbtn" onClick={submitReview}>
            Vélemény elküldése
          </button>
        </div>
      </section>
    </>
  );
}
