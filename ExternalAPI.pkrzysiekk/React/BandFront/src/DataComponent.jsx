import { useEffect, useState } from "react";

export default function DataComponent() {
  const [data, SetData] = useState([]);

  const handleClick = async () => {
    const fetchedData = await getData();
    SetData(fetchedData);
  };
  useEffect(() => {
    console.log(data);
  }, [data]);

  async function getData() {
    const url = "http://localhost:5247/band/";
    try {
      const response = await fetch(url);
      if (!response.ok) {
        alert("error while fetching data, try again");
      }
      const json = await response.json();
      return json;
    } catch (error) {
      alert(error);
    }
  }
  return <FetchButton handleFetchClick={handleClick} />;
}

function FetchButton({ handleFetchClick }) {
  return (
    <button className="fetch-button" onClick={handleFetchClick}>
      Fetch Data
    </button>
  );
}
