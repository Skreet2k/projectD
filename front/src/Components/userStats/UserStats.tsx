import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { api } from '../../lib/axios';

type Row = {
  levelId: string;
  levelName: string;
  score: number;
  won: boolean;
};

export default function UserStats() {
  const [tableData, setTableData] = useState<Row[]>([]);
  useEffect(() => {
    const fetch = async () => {
      const { data } = await api.get(
        'https://projectd.onebranch.dev/api/v1/scores/getuserscores',
      );

      setTableData(data.content);
    };

    fetch();
  }, []);
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Уровень</TableCell>
            <TableCell align="right">Победил</TableCell>
            <TableCell align="right">Счет</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {tableData.map((row: Row) => (
            <TableRow
              key={row.levelId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.levelName}
              </TableCell>
              <TableCell align="right">{row.won ? 'Да' : 'Нет'}</TableCell>
              <TableCell align="right">{row.score}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
