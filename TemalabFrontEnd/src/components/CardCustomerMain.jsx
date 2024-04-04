import "../App.css";
import PropTypes from 'prop-types'; 

export default function CardCustomerMain({data}) {
  const likeRestaurant = async (restaurantId) =>{
    const myHeaders = new Headers();

    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/LikedRestaurant/likeRestaurantForLoggedInUser?restaurantId=" + restaurantId, requestOptions);
      const result = await response.text();
      console.log(result)
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-6">
                <label className="card-text">{data.name}</label>
              </div>
              <div className="col-md-6 d-flex justify-content-end">
                <label className="card-text">{data.desctiption}</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">{data.label}</label>
              </div>
              <div className="col d-flex justify-content-end">
                <button className="likebtn" type = "button" onClick={() => likeRestaurant(data.id)}>
                  <img
                    src="./public/likebtn.png"
                    style={{ height: "40px", width: "40px" }}
                  />
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">{data.location}</label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}

CardCustomerMain.propTypes = {
  data: PropTypes.shape({
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  desctiption: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  location: PropTypes.string.isRequired
  }).isRequired,
};
