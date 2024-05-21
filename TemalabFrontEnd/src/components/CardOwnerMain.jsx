import "../App.css";
import PropTypes from 'prop-types'; 

export default function CardOwnerMain({data}) {

  const goEdit = () => {
    window.open("/editrestaurant/" + data.id, "_self");
  }

  return (
    <>
      <section id="main" className="container py-2 div-card position-relative">
        <a href={"/restaurantowner/" + data.id}>
          <div className="row div-card maincardmargin">
            <div className="container">
              <div className="row">
                <label className="card-text">{data.name}</label>
              </div>
              <div className="row">
                <label className="card-text">{data.label}</label>
              </div>
              <div className="row">
                <label className="card-Altext">{data.location}</label>
              </div>
            </div>
          </div>
        </a>
        <div className="position-absolute likeposowner">
          <button type="button" className="cardbtn float-end" onClick={goEdit}>
            Szerkesztés
          </button>
        </div>
      </section>
    </>
  );
}

CardOwnerMain.propTypes = {
  data: PropTypes.shape({
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  location: PropTypes.string.isRequired
  }).isRequired,
};
