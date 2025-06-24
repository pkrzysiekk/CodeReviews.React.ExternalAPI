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
  return (
    <>
      <FetchButton handleFetchClick={handleClick} />
      <TableData fetchedData={data} />
    </>
  );
}

function FetchButton({ handleFetchClick }) {
  return (
    <button className="fetch-button" onClick={handleFetchClick}>
      Fetch Data
    </button>
  );
}

function TableData({ fetchedData, getBandDetails }) {
  const tableBody = fetchedData.map((band, index) => (
    <tr key={index}>
      <td>{index + 1}</td>
      <td>{band.name}</td>
      <td>{band.genre}</td>
      <td>
        <button
          onClick={() => {
            getBandDetails;
          }}
        >
          Details
        </button>
      </td>
    </tr>
  ));
  return (
    <div className="table-data">
      <table>
        <thead>
          <tr>
            <th>Ordinal</th>
            <th>Name</th>
            <th>Genre</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>{tableBody}</tbody>
      </table>
    </div>
  );
}
