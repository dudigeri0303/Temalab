import "../App.css";

export default function CardAdminDeleteUser() {
 
  return (
    <>
          <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  UserName
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  Email
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  Role
                </label>
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