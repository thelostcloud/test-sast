# Monorepo with pnpm Workspaces

This is a monorepo managed with [pnpm](https://pnpm.io/) using the workspaces feature. It contains three console applications that are built with TypeScript and esbuild.

## Structure

```
.
├── app1/              # Console application 1
├── app2/              # Console application 2
├── app3/              # Console application 3
├── package.json       # Root package.json with workspace configuration
├── tsconfig.json      # Shared TypeScript configuration
├── .eslintrc.json     # ESLint configuration
└── pnpm-workspace.yaml # pnpm workspace definition
```

## Setup

Install dependencies:

```bash
pnpm install
```

## Building

Build all apps:

```bash
pnpm -r build
```

Build a specific app:

```bash
pnpm -C app1 build
```

## Development

Run watch mode for all apps:

```bash
pnpm -r dev
```

Run watch mode for a specific app:

```bash
pnpm -C app1 dev
```

## Running

Start an app:

```bash
pnpm -C app1 start
```

## Linting

Lint the entire monorepo:

```bash
pnpm lint
```

Lint and fix issues:

```bash
pnpm lint:fix
```

Lint a specific app:

```bash
pnpm -C app1 lint
```

## Scripts Explanation

- `-r` or `--recursive`: Run a script in all workspace packages
- `-C` or `--filter`: Run a script in a specific package

## Output

Each app generates:
- `src/index.ts` - TypeScript source file
- `dist/index.js` - Bundled and transpiled output

## Technologies

- **pnpm**: Workspace management
- **TypeScript**: Type-safe programming language
- **esbuild**: Fast bundler and transpiler
- **ESLint**: Code linting and quality
