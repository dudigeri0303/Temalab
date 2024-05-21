import "../App.css";
import { useEffect, useState } from "react";

export default function CommonProfile() {
  useEffect(() => {
    document.title = "Profile | DineTab";
  }, []);


  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');

  const getUserData = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      credentials: 'include',
      xhrFields: { withCredentials: true },
      headers: myHeaders,
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/User/getLoggedInUserData", requestOptions);
      let result = await response.text();
      result = JSON.parse(result);
      setUserName(result.name);
      setEmail(result.email);
      setPhoneNumber(result.phoneNumber);
      setPassword(result.password);

      // Dinamikusan állítjuk be a placeholder-eket a felhasználó adataival
      document.getElementById("nameForProfile").placeholder = result.name;
      document.getElementById("telForProfile").placeholder = result.phoneNumber;
      document.getElementById("emailForProfile").placeholder = result.email;
      document.getElementById("passwordForProfile").placeholder = result.password;
    } catch (error) {
      console.error(error);
    }
  };
  useEffect(() => {
    getUserData();
  }, []);

  const deleteProfile = () => {
    const IsProfileDeleted = window.confirm("Biztos törlöd a profilod?");
    if (IsProfileDeleted) {
      console.log('eljut a profil torlesehez');
  
      const deleteUser = async () => {
        const myHeaders = new Headers();
  
        const requestOptions = {
          method: "DELETE",
          headers: myHeaders,
          credentials: 'include',
          xhrFields: { withCredentials: true },
          redirect: "follow"
        };
  
        try {
          const response = await fetch("https://localhost:7114/api/User/deleteUserById", requestOptions);
          if (response.ok) {
            window.open("/", "_self");
            alert("Profil törölve");
          } else {
            throw new Error('Hiba történt a profil törlése során');
          }
        } catch (error) {
          console.error(error);
        }
      };
  
      deleteUser();
    }
  };

  const [modifiable, setModifiable] = useState(false);

  const modify = () => {
    setModifiable(true);
  };

  const cancelModify = () => {
    setModifiable(false);
    location.reload();
  };


  const saveChanges = () => {
    setModifiable(false);

    const newData = {
      userName: userName,
      phoneNumber: phoneNumber,
      email: email
    };

    const putRequestOptions = {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      credentials: 'include',
      body: JSON.stringify(newData)
    };

    fetch("https://localhost:7114/api/User/updateUserForLoggedInUser", putRequestOptions)
      .then(handleResponse)
      .catch(handleError);

    function handleResponse(response) {
      if (response.ok) {
        alert("Változtatások mentve");
      } else {
        throw new Error('Hiba történt a mentés során');
      }
    }

    function handleError(error) {
      console.error('Hiba történt:', error);
    }
  };

  return (
    <>
      <section id="main" className="container py-3">
        <form method="post">
          <div className="row">
            <div className="col-md-8">
              <div className="col-md-3 offset-md-4 mb-2">
                <button onClick={modify} type="button" className="avgbtn float-md-right">
                  Profil szerkesztése
                </button>
              </div>
            </div>

            <h4 className="h4-profile">Profil Adatok:</h4>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="nameForProfile" className="form-label">
                  Név:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="text"
                  className="form-control"
                  id="nameForProfile"
                  name="nameForProfile"
                  value={userName}
                  onChange={(e) => setUserName(e.target.value)}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-6 d-flex justify-content-center">
                <label htmlFor="telForProfile" className="form-label">
                  Telefon:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="text"
                  className="form-control"
                  id="telForProfile"
                  name="telForProfile"
                  value={phoneNumber}
                  onChange={(e) => setPhoneNumber(e.target.value)}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="emailForProfile" className="form-label">
                  Email:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="email"
                  className="form-control"
                  id="emailForProfile"
                  name="emailForProfile"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="passwordForProfile" className="form-label">
                  Jelszó:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="password"
                  className="form-control"
                  id="passwordForProfile"
                  name="passwordForProfile"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col-md-3 offset-md-5 mb-2">
              <button onClick={saveChanges} type="button" className="avgbtn">
                Változtatások mentése
              </button>
            </div>
            <div className="col-md-2 offset-md-1 mb-2">
              <button onClick={cancelModify} type="button" className="avgbtn">
                Mégse
              </button>
            </div>
          </div>
        </form>

        <div className="row">
          <div className="col-md-3 offset-md-5 mb-2">
            <button onClick={deleteProfile} type="button" className="redbtn">
              Profil törlése
            </button>
          </div>
        </div>
      </section>
    </>
  );
}