import { useEffect, useState } from "react";

export default function DataComponent() {
  const [data, setData] = useState([]);
  const [selectedBand, setSelectedBand] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const handleClick = async () => {
    setIsLoading(true);
    const fetchedData = await getData();
    setData(fetchedData);
    setIsLoading(false);
  };

  const handleGetDetails = (id) => {
    const bandDetails = data.find((band) => band.id == id);
    setSelectedBand(bandDetails);
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
      <div className="main">
        <div className="left-side">
          {data.length === 0 || (
            <TableData fetchedData={data} getBandDetails={handleGetDetails} />
          )}
          {isLoading && <p className="loading-p">Loading Data...</p>}
          <FetchButton handleFetchClick={handleClick} />
        </div>
        <div className="right-side">
          {selectedBand && <BandCard bandData={selectedBand} />}
        </div>
      </div>
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
            getBandDetails(band.id);
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

function BandCard({ bandData }) {
  console.log(bandData);
  return (
    <div className="band-card">
      <div className="card-image">
        <img src={bandData.imageURL} />
      </div>
      <div className="card-info">
        <h3>{bandData.name}</h3>
      </div>
    </div>
  );
}
