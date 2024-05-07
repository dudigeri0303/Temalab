/* eslint-disable react/prop-types */
import "../App.css";

export default function CardAdminDeleteUser({data}) {

  const deleteUser = async(dataId) =>{
      // itt lesz majd a delet user csak nincs rá rest api
  }
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.userName}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.email}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Role</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end" onClick={() => deleteUser(data.id)}>
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