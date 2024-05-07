import "../App.css";
import { useEffect, useState } from "react";
import AdminNavbar from "../components/AdminNavbar";
import CardAdminDeleteUser from "../components/CardAdminDeleteUser";

export default function AdminDeleteUser() {
  useEffect(() => {
    document.title = "Felhasználó törlése | DineTab";
    getUsers();
  }, []);

  const [users, setUsers] = useState([]);

  const getUsers = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true }
    };

    try {
      const response = await fetch("https://localhost:7114/api/User/getAllUsers", requestOptions);
      const data = await response.json();
      setUsers(data);
      console.log(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="min-vh-100">
      <AdminNavbar />
      {users.length === 0 ? (
        <label className="placeholerLabel">Még nincsenek törlendő felhasználók</label>
      ) : (
        <section id="main" className="container py-2">
          <div className="row">
            {users.map((user) => (
              <div className="col-12 mb-3" key={user.id}>
                <CardAdminDeleteUser data={user} />
              </div>
            ))}
          </div>
        </section>
      )}
    </div>
  );

}