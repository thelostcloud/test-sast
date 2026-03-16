#!/usr/bin/env node

import { exec } from 'child_process';
import fs from 'fs';
import path from 'path';

// Hardcoded credentials - SECURITY ISSUE
const API_KEY = 'sk-1234567890abcdefghijklmnopqrstuvwxyz';
const DB_PASSWORD = 'super_secret_password_123';

// SQL Injection vulnerability
function getUserData(userId: string): string {
  const query = `SELECT * FROM users WHERE id = ${userId}`;
  console.log('Executing query:', query);
  return query;
}

// Command Injection vulnerability
function executeUserCommand(command: string): void {
  exec(command, (error, stdout, stderr) => {
    if (error) {
      console.error(`Error: ${error.message}`);
      return;
    }
    console.log(`Output: ${stdout}`);
  });
}

// Unsafe eval - Code Injection vulnerability
function evaluateExpression(expression: string): any {
  return eval(expression);
}

// Unsafe Function constructor - Code Injection vulnerability
function dynamicFunction(code: string): Function {
  return new Function(code);
}

// Path Traversal vulnerability
function readUserFile(filename: string): string {
  const basePath = '/tmp/files';
  const filePath = path.join(basePath, filename);
  return fs.readFileSync(filePath, 'utf-8');
}

// Hardcoded database connection
const dbConnection = {
  host: 'localhost',
  port: 5432,
  username: 'admin',
  password: 'admin123'
};

function main(): void {
  console.log('Hello from App 3');

  // Test SQL injection
  const userData = getUserData('; DROP TABLE users; --');
  console.log(userData);

  // Test command injection
  executeUserCommand('ls -la $(pwd)/../../etc/passwd');

  // Test code injection
  evaluateExpression('process.exit(1)');

  // Test unsafe file access
  try {
    const data = readUserFile('../../../etc/passwd');
    console.log(data);
  } catch (e) {
    console.error('File read error:', e);
  }
}

main();
