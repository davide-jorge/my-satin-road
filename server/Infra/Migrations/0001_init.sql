create table users (
                       id            uuid primary key default gen_random_uuid(),
                       email         text not null unique,
                       username      text not null unique,
                       password_hash text not null,
                       role          text not null default 'User' check (role in ('User','Admin')),
                       gold          bigint not null default 1000 check (gold >= 0),
                       created_at    timestamptz not null default now()
);

create table vendors (
                         user_id       uuid primary key references users(id),
                         shop_name     text not null unique,
                         status        text not null default 'Active' check (status in ('Active','Suspended','Banned')),
                         status_reason text,
                         status_changed_at timestamptz,
                         created_at    timestamptz not null default now()
);

create table categories (
                            id          int generated always as identity primary key,
                            name        text not null unique,
                            slug        text not null unique,
                            description text,
                            created_at  timestamptz not null default now()
);