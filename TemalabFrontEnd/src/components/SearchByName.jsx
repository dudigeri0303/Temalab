import "@fortawesome/fontawesome-free/css/all.min.css";

export default function SearchByName() {
  const matches = [];
  const searchedName = document.getElementById("searchedName");
  //const list = JSON.parse(lista.JSON) <- majd a paraméter list nem kell, hiszen itt példányosítom
  //ha lehet, érdemes lenne megoldani, hogy a list az oldaltól függően változzon,
  //akkor minden kártyához meglehet hívni ezt a keresést

  const search = (list) => {
    for (var i = 0; i < list.length; i++) {
      if (list[i].name.toLowerCase().includes(searchedName.toLowerCase())) {
        matches.push(list[i]);
      }
    }
    return matches;
  };

  // hívunk egy render-t a search-re, vagy nem kell return és akkor a matches-re
  // hogy kirajzolja a találatokat, ugyanazt a fv-t, amit minden kártya oldal elején kell

  return (
    <>
      <div className="row justify-content-center">
        <div className="col-md-4">
          <div className="input-group rounded">
            <input
              type="search"
              id="searchedName"
              className="form-control rounded"
              placeholder="Search"
              aria-label="Search"
              aria-describedby="search-addon"
            />
            <button
              className="input-group-text border-0"
              id="search-addon"
              onClick={search}
            >
              <i className="fas fa-search"></i>
            </button>
          </div>
        </div>
      </div>
    </>
  );
}
