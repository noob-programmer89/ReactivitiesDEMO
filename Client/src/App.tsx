import { useEffect, useState } from "react";
import { Typography, List, ListItem, ListItemText } from "@mui/material";
import axios from "axios";

function App() {

  const[activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    // fetch("https://localhost:5001/api/Activities")
    // .then(response => response.json())
    // .then(data => setActivities(data));
    axios.get<Activity[]>("https://localhost:5001/api/Activities")
    .then(response => setActivities(response.data));
  }, []);

  return (
    <>
      <Typography variant='h3'>Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
