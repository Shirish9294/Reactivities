import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header } from 'semantic-ui-react';
import { Activity } from '../../models/activity';
import NavBar from './NavBar';
import ActivitiyDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {
  const[activities,setActivities]=useState<Activity[]>([]);
  const[selectedActivitiy, setSelectedActivity]=useState<Activity | undefined>(undefined);
  const[editMode, setEditMode]=useState(false);
  useEffect(()=>{
    axios.get('http://localhost:5000/api/Activities')
    .then(response=>{
      console.log(response);
      setActivities(response.data);
    })
  }, [])

  function handleSelectActivity(id: string){
    setSelectedActivity(activities.find(x=>x.id===id))
  }

  function handleCancelSelectActivity(){
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?:string){
    id? handleSelectActivity(id):handleCancelSelectActivity();
    setEditMode(true);
  }

  function handleFormClose(){
    setEditMode(false);
  }

  return (
    <>
      <NavBar/>
      <Container style={{marginTop:'7em'}}>
        <ActivitiyDashboard activities={activities}
        selectedActivity={selectedActivitiy}
        selectActivity={handleSelectActivity}
        cancelSelectActivity={handleCancelSelectActivity}
        editMode={editMode}
        openForm={handleFormOpen}
        closeForm={handleFormClose}/>
        </Container>
    </>
  );
}

export default App;
