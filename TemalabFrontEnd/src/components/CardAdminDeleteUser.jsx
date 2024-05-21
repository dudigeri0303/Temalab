/* eslint-disable react/prop-types */
import "../App.css";

export default function CardAdminDeleteUser({data}) {

  const deleteUser = async(dataId) =>{
      // itt lesz majd a delet user csak nincs rá rest api
    console.log(dataId)
    const myHeaders = new Headers();

    const requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/User/deleteUserByIdWithAdmin?userId=" + dataId, requestOptions);
      const result = await response.text();
      console.log(result);
      window.location.reload();
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