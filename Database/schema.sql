-- Core Model Tables
create table if not exists public.tbluser (
  uid bigint generated always as identity primary key,
  name text not null default '',
  email text not null default '',
  password text not null default '',
  role text not null default 'STUDENT',
  is_active integer not null default 1,
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tbladmin (
  aid bigint primary key,
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblstudent (
  studid bigint primary key,
  rank text not null default 'Novice',
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblprofessor (
  pid bigint primary key,
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblbadge (
  bid bigint generated always as identity primary key,
  badgename text not null default '',
  criteriamet text not null default '',
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblchallenge (
  cid bigint generated always as identity primary key,
  category text not null default 'Binary',
  target_number integer not null default 0,
  time_limit integer not null default 30,
  difficulty_level text not null default 'Easy',
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblscorerecord (
  srid bigint generated always as identity primary key,
  final_score integer not null default 0,
  date_completed timestamptz not null default now(),
  time_taken integer not null default 0,
  is_passed integer not null default 0,
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblsection (
  sid bigint generated always as identity primary key,
  section_name text not null default '',
  semester text not null default '1st',
  year text not null default '2026',
  section_password text not null default '',
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblchallenge_feedback (
  fbid bigint generated always as identity primary key,
  cid bigint not null,
  studid bigint not null,
  rating integer not null default 0,
  comment_text text not null default '',
  date_submitted timestamptz not null default now(),
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

create table if not exists public.tblfeedback_reply (
  reply_id bigint generated always as identity primary key,
  fbid bigint not null,
  uid bigint not null,
  reply_text text not null default '',
  date_replied timestamptz not null default now(),
  deleted_at timestamptz,
  created_at timestamptz not null default now()
);

-- Junction Tables
create table if not exists public.tblsection_professor (
  sid bigint not null,
  pid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (sid, pid)
);

create table if not exists public.tblsection_student (
  sid bigint not null,
  studid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (sid, studid)
);

create table if not exists public.tblchallenge_section (
  cid bigint not null,
  sid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (cid, sid)
);

create table if not exists public.tblstudent_record (
  studid bigint not null,
  srid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (studid, srid)
);

create table if not exists public.tblchallenge_record (
  cid bigint not null,
  srid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (cid, srid)
);

create table if not exists public.tblstudent_badge (
  bid bigint not null,
  studid bigint not null,
  deleted_at timestamptz,
  created_at timestamptz not null default now(),
  primary key (bid, studid)
);

-- Indexes
create index if not exists tbluser_email_idx on public.tbluser (email);
create index if not exists tblbadge_badgename_idx on public.tblbadge (badgename);
create index if not exists tblchallenge_category_idx on public.tblchallenge (category);
create index if not exists tblsection_section_name_idx on public.tblsection (section_name);
create index if not exists tblchallenge_feedback_cid_idx on public.tblchallenge_feedback (cid);
create index if not exists tblfeedback_reply_fbid_idx on public.tblfeedback_reply (fbid);

-- Grants, RLS & Policies for Anon (Class Use)
grant select, insert, update, delete on public.tbluser to anon;
alter table public.tbluser enable row level security;
create policy "read_all" on public.tbluser for select to anon using (true);
create policy "insert_all" on public.tbluser for insert to anon with check (true);
create policy "update_all" on public.tbluser for update to anon using (true) with check (true);
create policy "delete_all" on public.tbluser for delete to anon using (true);

grant select, insert, update, delete on public.tbladmin to anon;
alter table public.tbladmin enable row level security;
create policy "read_all" on public.tbladmin for select to anon using (true);
create policy "insert_all" on public.tbladmin for insert to anon with check (true);
create policy "update_all" on public.tbladmin for update to anon using (true) with check (true);
create policy "delete_all" on public.tbladmin for delete to anon using (true);

grant select, insert, update, delete on public.tblstudent to anon;
alter table public.tblstudent enable row level security;
create policy "read_all" on public.tblstudent for select to anon using (true);
create policy "insert_all" on public.tblstudent for insert to anon with check (true);
create policy "update_all" on public.tblstudent for update to anon using (true) with check (true);
create policy "delete_all" on public.tblstudent for delete to anon using (true);

grant select, insert, update, delete on public.tblprofessor to anon;
alter table public.tblprofessor enable row level security;
create policy "read_all" on public.tblprofessor for select to anon using (true);
create policy "insert_all" on public.tblprofessor for insert to anon with check (true);
create policy "update_all" on public.tblprofessor for update to anon using (true) with check (true);
create policy "delete_all" on public.tblprofessor for delete to anon using (true);

grant select, insert, update, delete on public.tblbadge to anon;
alter table public.tblbadge enable row level security;
create policy "read_all" on public.tblbadge for select to anon using (true);
create policy "insert_all" on public.tblbadge for insert to anon with check (true);
create policy "update_all" on public.tblbadge for update to anon using (true) with check (true);
create policy "delete_all" on public.tblbadge for delete to anon using (true);

grant select, insert, update, delete on public.tblchallenge to anon;
alter table public.tblchallenge enable row level security;
create policy "read_all" on public.tblchallenge for select to anon using (true);
create policy "insert_all" on public.tblchallenge for insert to anon with check (true);
create policy "update_all" on public.tblchallenge for update to anon using (true) with check (true);
create policy "delete_all" on public.tblchallenge for delete to anon using (true);

grant select, insert, update, delete on public.tblscorerecord to anon;
alter table public.tblscorerecord enable row level security;
create policy "read_all" on public.tblscorerecord for select to anon using (true);
create policy "insert_all" on public.tblscorerecord for insert to anon with check (true);
create policy "update_all" on public.tblscorerecord for update to anon using (true) with check (true);
create policy "delete_all" on public.tblscorerecord for delete to anon using (true);

grant select, insert, update, delete on public.tblsection to anon;
alter table public.tblsection enable row level security;
create policy "read_all" on public.tblsection for select to anon using (true);
create policy "insert_all" on public.tblsection for insert to anon with check (true);
create policy "update_all" on public.tblsection for update to anon using (true) with check (true);
create policy "delete_all" on public.tblsection for delete to anon using (true);

grant select, insert, update, delete on public.tblchallenge_feedback to anon;
alter table public.tblchallenge_feedback enable row level security;
create policy "read_all" on public.tblchallenge_feedback for select to anon using (true);
create policy "insert_all" on public.tblchallenge_feedback for insert to anon with check (true);
create policy "update_all" on public.tblchallenge_feedback for update to anon using (true) with check (true);
create policy "delete_all" on public.tblchallenge_feedback for delete to anon using (true);

grant select, insert, update, delete on public.tblfeedback_reply to anon;
alter table public.tblfeedback_reply enable row level security;
create policy "read_all" on public.tblfeedback_reply for select to anon using (true);
create policy "insert_all" on public.tblfeedback_reply for insert to anon with check (true);
create policy "update_all" on public.tblfeedback_reply for update to anon using (true) with check (true);
create policy "delete_all" on public.tblfeedback_reply for delete to anon using (true);

grant select, insert, update, delete on public.tblsection_professor to anon;
alter table public.tblsection_professor enable row level security;
create policy "read_all" on public.tblsection_professor for select to anon using (true);
create policy "insert_all" on public.tblsection_professor for insert to anon with check (true);
create policy "update_all" on public.tblsection_professor for update to anon using (true) with check (true);
create policy "delete_all" on public.tblsection_professor for delete to anon using (true);

grant select, insert, update, delete on public.tblsection_student to anon;
alter table public.tblsection_student enable row level security;
create policy "read_all" on public.tblsection_student for select to anon using (true);
create policy "insert_all" on public.tblsection_student for insert to anon with check (true);
create policy "update_all" on public.tblsection_student for update to anon using (true) with check (true);
create policy "delete_all" on public.tblsection_student for delete to anon using (true);

grant select, insert, update, delete on public.tblchallenge_section to anon;
alter table public.tblchallenge_section enable row level security;
create policy "read_all" on public.tblchallenge_section for select to anon using (true);
create policy "insert_all" on public.tblchallenge_section for insert to anon with check (true);
create policy "update_all" on public.tblchallenge_section for update to anon using (true) with check (true);
create policy "delete_all" on public.tblchallenge_section for delete to anon using (true);

grant select, insert, update, delete on public.tblstudent_record to anon;
alter table public.tblstudent_record enable row level security;
create policy "read_all" on public.tblstudent_record for select to anon using (true);
create policy "insert_all" on public.tblstudent_record for insert to anon with check (true);
create policy "update_all" on public.tblstudent_record for update to anon using (true) with check (true);
create policy "delete_all" on public.tblstudent_record for delete to anon using (true);

grant select, insert, update, delete on public.tblchallenge_record to anon;
alter table public.tblchallenge_record enable row level security;
create policy "read_all" on public.tblchallenge_record for select to anon using (true);
create policy "insert_all" on public.tblchallenge_record for insert to anon with check (true);
create policy "update_all" on public.tblchallenge_record for update to anon using (true) with check (true);
create policy "delete_all" on public.tblchallenge_record for delete to anon using (true);

grant select, insert, update, delete on public.tblstudent_badge to anon;
alter table public.tblstudent_badge enable row level security;
create policy "read_all" on public.tblstudent_badge for select to anon using (true);
create policy "insert_all" on public.tblstudent_badge for insert to anon with check (true);
create policy "update_all" on public.tblstudent_badge for update to anon using (true) with check (true);
create policy "delete_all" on public.tblstudent_badge for delete to anon using (true);